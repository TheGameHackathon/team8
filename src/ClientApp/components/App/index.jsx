import React from 'react';
import StatusPanel from './StatusPanel';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor() {
        super();
        this.state = {
            score: 0,
            cardState: [
                {
                    "type": 1,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                },
                {
                    "type": 0,
                    "isFlipped": false
                }
            ]
        };
    }

    render() {
        return (
            <div className={styles.root}>
                <StatusPanel score={this.state.score}></StatusPanel>
                <Field cardState={this.state.cardState} rows={4} cardsInRow={8}/>
            </div>
        );
    }
}
