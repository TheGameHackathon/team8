import React from 'react';
import classNames from 'classnames';
import styles from './styles.css'

import cardBack0 from './cards/0.png';
import cardBack1 from './cards/1.png';
import cardBack2 from './cards/2.png';
import cardBack3 from './cards/3.png';
import cardBack4 from './cards/4.png';
import cardBack5 from './cards/5.png';
import cardBack6 from './cards/6.png';
import cardBack7 from './cards/7.png';
import cardBack8 from './cards/8.png';
import cardBack9 from './cards/9.png';
import cardBack10 from './cards/10.png';
import cardBack11 from './cards/11.png';
import cardBack12 from './cards/12.png';
import cardBack13 from './cards/13.png';
import cardBack14 from './cards/14.png';
import cardBack15 from './cards/15.png';

const cards = [cardBack0,
    cardBack1,
    cardBack2,
    cardBack3,
    cardBack4,
    cardBack5,
    cardBack6,
    cardBack7,
    cardBack8,
    cardBack9,
    cardBack10,
    cardBack11,
    cardBack12,
    cardBack13,
    cardBack14,
    cardBack15];

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
        state[cardId].isFlipped = true;
        this.setState({cardState: state})
    }

    renderCard(cardId) {
        const typeId = this.state.cardState[cardId].type;
        const isFlipped = this.state.cardState[cardId].isFlipped;
        let cardDivId = "card_" + cardId;
        return (
            <td className={styles.cell} key={cardDivId}>
                <div onClick={!isFlipped && (() => this.switchCard(cardId))}
                     className={isFlipped ? classNames(styles.card, styles.cardFlipped) : styles.card}
                     id={cardDivId}>
                    <div className={classNames(styles.cardSide, styles.cardBack)}/>
                    <div className={classNames(styles.cardSide, styles.cardFace)}
                         style={{backgroundImage: `url(${cards[typeId]})`}}/>
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
