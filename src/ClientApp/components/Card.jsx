import React, {Component} from "react";
import styles from './styles.css';

export class Card extends Component {
    render(){
        let cardId = this.card.id;

        return(
            <td>{cardId}</td>
        );
    }
}
