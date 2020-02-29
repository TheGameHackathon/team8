import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor (props) {
        super(props);
        this.state = {
            score: 50,
        };
        this.gameId = props.gameId;
    }

    updateScore(score) {
        this.setState({score: score});
    }

    componentDidMount() {
        this.updater = setTimeout(() => fetch("http://localhost:5000/api/game/score")
            .then(response => response.json())
            .then(this.updateScore))
    }

    render() {
        return (
            <div className={styles.root}>
                <div className={styles.score}>
                    Ваш счет: {this.state.score}
                </div>
                <Field gameId={this.gameId}/>
            </div>
        );
    }

    componentWillUnmount() {
        clearTimeout(this.updater)
    }
}
