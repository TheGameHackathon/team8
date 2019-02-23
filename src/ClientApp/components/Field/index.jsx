import React from 'react';
import classNames from 'classnames';
import styles from './styles.css'
import Background from './images/card-joker.png';

export default class Field extends React.Component {
    constructor({cardState, rows, cardsInRow}) {
        super();
        this.state = {
            cardState: cardState,
            rowsCount: rows,
            cardsInRow: cardsInRow
        };
    }

    switchCard(cardId) {
        console.log(cardId);
        const state = this.state.cardState;
        state[cardId] = 1;
        this.setState({cardState: state})
    }

    renderCard(cardId) {
        const typeId = this.state.cardState[cardId];
        let cardDivId = "card_" + cardId;
        return (
            <td className={styles.cell} key={cardDivId}>
                <div onClick={typeId === -1 && (() => this.switchCard(cardId))}
                     className={typeId === -1 ? styles.card : classNames(styles.card, styles.cardFlipped)}
                     id={cardDivId}>
                    <div className={classNames(styles.cardSide, styles.cardBack)}/>
                    <div className={classNames(styles.cardSide, styles.cardFace)}
                         style={{backgroundImage: `url(${Background})`}}/>
                </div>
            </td>);

    }

    renderRow(rowId) {
        const cards = [];
        for (let i = 0; i < this.state.cardsInRow; i++) {
            cards.push(this.renderCard(rowId * this.state.cardsInRow + i));
        }
        return (
            <tr className={styles.row} key={rowId}>
                {cards}
            </tr>
        );
    }

    render() {
        const rows = [];
        for (let i = 0; i < this.state.rowsCount; i++) {
            rows.push(this.renderRow(i));
        }
        return (
            <table className={styles.field}>
                <tbody>
                {rows}
                </tbody>
            </table>
        );
    }
}
