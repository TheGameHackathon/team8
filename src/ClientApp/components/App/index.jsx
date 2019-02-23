import React from 'react';
import styles from './styles.css';
import Field from '../Field';
import Button from '@skbkontur/react-ui/Button';
import StatusPanel from "./StatusPanel";

export default class App extends React.Component {
    constructor() {
        super();
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
                    r.json().then(j => {
                        setTimeout(() => this.setState({gameIsLoading: false, cardState: j}),
                            this.state.cardState ? 500 : 0
                        );
                    });
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
                    <StatusPanel score={this.state.score}/>
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
        const state = this.state.cardState;
        state[cardId].isFlipped = true;
        this.setState({cardState: state});
        this.updateScore();
    }
}
