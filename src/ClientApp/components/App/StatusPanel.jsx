import React from 'react';
import styles from './styles.css';

export default class App extends React.Component {

    render() {
        let score = this.props.score;

        return (
            <header className={styles.status}>
                <label className={styles.score}>Ваш счет: {score}</label>
                <label className={styles.score}>Время: -Infinity</label>
            </header>
        );
    }
}
