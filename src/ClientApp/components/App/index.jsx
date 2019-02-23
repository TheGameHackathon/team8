import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor() {
        super();
        this.state = {
            score: 0,
            cardState: [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1]
        };
    }

    render() {
        return (
            <div className={styles.root}>
                <span className={styles.score}>
                    Ваш счет: {this.state.score}
                </span>
                <Field cardState={this.state.cardState} rows={4} cardsInRow={8}/>
            </div>
        );
    }
}
