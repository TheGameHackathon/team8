import React from 'react';
import styles from './styles.css';
import Field from '../Field';
import StatusPanel from "./StatusPanel";

export default class App extends React.Component {
    constructor() {
        super();
        this.cardsToFlip = 2;
        this.state = {
            score: 0,
            gameIsLoading: false
        };
    }

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
        this.setState({gameIsLoading: true});
        fetch("/api/game/start")
            .then(r => {
                if (r.status === 200) {
                    Promise.all([this.delay(this.state.cardState ? 500 : 0), r.json()])
                        .then(([_, j]) => this.setState({
                            gameIsLoading: false,
                            cardState: j
                        }));
                } else {
                    this.setState({gameIsLoading: false});
                }
            });
    }

    render() {
        return (
            <div className={styles.root}>
                <StatusPanel score={this.state.score}/>
                <input type="button"
                       value={this.state.gameIsLoading ? "Загрузка..." : "Начать игру"}
                       disabled={this.state.gameIsLoading}
                       onClick={() => this.startGame()}/>
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
                        this.setState({cardState: j});
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
