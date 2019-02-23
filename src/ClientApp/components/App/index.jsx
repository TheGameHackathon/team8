import React from 'react';
import styles from './styles.css';
import Field from '../Field';
import Button from '@skbkontur/react-ui/Button';
import StatusPanel from "./StatusPanel";

export default class App extends React.Component {
    constructor() {
        super();
        this.cardsToFlip = 2;
        this.state = {
            score: 0,
            time: 0,
            gameIsLoading: false
        };
        this.intervalId = null;
    }

    // noinspection JSMethodCanBeStatic
    updateScore() {
        fetch("/api/game/score")
            .then(r => {
                if (r.status === 200) {
                    r.json().then(j => {
                        this.setState({score: j});
                    });
                }
            });
    }

    startGame() {
        if (this.intervalId) {
            clearInterval(this.intervalId);
            this.setState({time: 0});
        }
        this.setState({gameIsLoading: true});
        fetch("/api/game/start")
            .then(r => {
                if (r.status === 200) {
                    Promise.all([this.delay(this.state.cardState ? 500 : 0), r.json()])
                        .then(([_, j]) => this.setState({
                            gameIsLoading: false,
                            cardState: j,
                            time: 0
                        }));
                    this.cardsToFlip = 2;
                    this.intervalId = setInterval(() => this.setState({time: this.state.time + 1}), 1000);
                    this.updateScore();
                } else {
                    this.setState({gameIsLoading: false});
                }
            });
    }

    render() {
        return (
            <div className={styles.root}>
                <div className={styles.panel}>
                    <Button use="pay" size="medium"
                            className={styles.startButton}
                            disabled={this.state.startingGame}
                            onClick={() => this.startGame()}>
                        {this.state.startingGame ? "Загрузка..." : "Начать игру"}
                    </Button>
                    <StatusPanel score={this.state.score} time={this.state.time}/>
                </div>
                {this.renderField()}
            </div>
        );
    }

    renderField() {
        return this.state.cardState &&
            <Field switchCard={(id => this.switchCard(id))}
                   cardState={this.state.cardState}
                   rowsCount={4}
                   cardsInRow={8}
                   gameIsLoading={this.state.gameIsLoading}
            />;
    }

    switchCard(cardId) {
        if (this.cardsToFlip <= 0)
            return;
        this.cardsToFlip--;
        const state = this.state.cardState;
        state[cardId].isFlipped = true;
        this.setState({cardState: state});
        this.delay(this.cardsToFlip === 0 ? 1000 : 0).then(() =>
            this.makeTurn(cardId));
    }

    makeTurn(cardId) {
        fetch('/api/game/turn',
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({position: cardId})
            }
        ).then(r => {
                if (r.status === 200) {
                    if (this.cardsToFlip <= 0) {
                        this.cardsToFlip = 2;
                    }
                    r.json().then(j => {
                        this.setState({cardState: j.map});
                        this.updateScore();
                    });
                }
            }
        );
    }

    delay(amount) {
        return new Promise(resolve => {
            setTimeout(() => resolve(), amount);
        });
    }
}
