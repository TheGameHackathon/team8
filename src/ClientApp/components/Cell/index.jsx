import React from "react";
import styles from './styles.css';
import jokerImage from './images/card-joker.png'
import b2Image from './images/2b.png'
import b3Image from './images/3b.png'
import b4Image from './images/4b.png'
import b5Image from './images/5b.png'
import b6Image from './images/6b.png'
import b7Image from './images/7b.png'
import b8Image from './images/8b.png'
// import b7Image from './images/7b.png'
// import b8Image from './images/8b.png'

const cards = [b2Image, b3Image, b4Image, b5Image, b6Image, b7Image, b8Image];

export default class Cell extends React.Component {
    constructor(props) {
        super(props);
        this.id = props.id;
        this.card = {x: props.id % 4, y: props.id / 4, isOpened: false, isGuessed: false, id: 0}
    }

    render() {
        return (<td className={styles.cell}>
            <div className={styles.card} onClick={(e) => this.flipCard(e, this.id)} id={this.id}>
                <div className={styles.cardSide + ' ' + styles.cardBack}/>
                <div className={styles.cardSide + ' ' + styles.cardFace} style={{
                    backgroundImage: `url(${cards[this.id % cards.length]})`,
                    transform: 'rotateY(180deg)',
                    backgroundSize: 'cover',
                    backgroundRepeat: 'no-repeat',
                    backgroundPosition: 'center'
                }}/>
            </div>
        </td>);
    }

    flipCard(e, id) {
        const target = document.getElementById(id);
        console.log(target.classList);
        setTimeout(() => {
            console.log("FLip");
            if (!target.classList.contains(styles.cardFlipped))
                target.classList.add(styles.cardFlipped);
            else
                target.classList.remove(styles.cardFlipped);

        }, 0);
        
    }
}