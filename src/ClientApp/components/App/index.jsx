import React from 'react';
import styles from './styles.css';
import Field from '../Field';
import StatusPanel from "./StatusPanel";

export default class App extends React.Component {
    constructor() {
        super();
        this.state = {
            score: 0,
            startingGame: false
        };
    }

    startGame() {
        this.setState({startingGame: true});
        fetch("/api/game/start")
            .then(r => {
                if (r.status === 200) {
                    r.json().then(j => {
                        console.log(j);
                        return this.setState({startingGame: false, cardState: j});
                    });
                } else {
                    console.log(r);
                    this.setState({startingGame: false});
                }
            });
    }

    render() {
        return (
            <div className={styles.root}>
                <StatusPanel score={this.state.score}/>
                <input type="button"
                       value={this.state.startingGame ? "Загрузка..." : "Начать игру"}
                       disabled={this.state.startingGame}
                       onClick={() => this.startGame()}/>
                {this.renderField()}
            </div>
        );
    }

    renderField() {
        return this.state.cardState &&
            <Field switchCard={(id => this.switchCard(id))} cardState={this.state.cardState}
                   rowsCount={4} cardsInRow={8}/>;
    }

    switchCard(cardId) {
        console.log(cardId);
        const state = this.state.cardState;
        state[cardId].isFlipped = true;
        this.setState({cardState: state})
    }
}
