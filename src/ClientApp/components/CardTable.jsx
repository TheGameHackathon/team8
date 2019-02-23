import React, { Component } from "react";
import Card from './Card';
import styles from './styles.css';

export class CardTable extends Component {
    
    constructor(){
        let pairId = 0;
        let cards = [];
        for (let i = 0; i < 16; i++) {
            cards.push({ id: i, pairId: pairId / 2 })
        }

        this.setState({cards: getCards})
    }

    render() {
        let cardsInRow = []
        return(
            cards.map((card, index) => {
                if (index % 4 != 0) {
                    cardsInRow.push(card)
                }
                else{
                    <tr>
                        {cardsInRow.map(card => {
                            <Card card = {card}/>
                        })}
                    </tr>
                }
            })
        );
    }
}
