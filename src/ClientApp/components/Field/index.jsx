import React from 'react';
import classNames from 'classnames';
import styles from './styles.css'
import Background from './images/card-joker.png';

export default class Field extends React.Component {
    constructor({cardState, rows, cardsInRow}) {
        super();
        this.cardState = cardState;
        this.rowsCount = rows;
        this.cardsInRow = cardsInRow;
    }

    renderCard(cardId) {
        const typeId = this.cardState[cardId];
        let cardDivId = "card_" + cardId;
        return (
            <td className={styles.cell}>
                <div
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
        for (let i = 0; i < this.cardsInRow; i++) {
            cards.push(this.renderCard(rowId * this.cardsInRow + i));
        }
        return (
            <tr className={styles.row}>
                {cards}
            </tr>
        );
    }

    render() {
        const rows = [];
        for (let i = 0; i < this.rowsCount; i++) {
            rows.push(this.renderRow(i));
        }
        return (
            <table className={styles.field}>
                {rows}
            </table>
        );
    }
}
