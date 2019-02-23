import React from 'react';
import styles from './styles.css';

export default class StatusPanel extends React.Component {

    render() {
        return (
            <header className={styles.status}>
                <label className={styles.score}>Ваш счет: {this.props.score}</label>
                <label className={styles.score}>Время: {this.props.time}</label>
            </header>
        );
    }
}
