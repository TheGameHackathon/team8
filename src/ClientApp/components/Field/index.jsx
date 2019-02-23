import React from 'react';
import classNames from 'classnames';
import styles from './styles.css'
import Background from './images/card-joker.png';


export default class Field extends React.Component {
    render() {
        return (
            <table className={styles.field}>
                <tr className={styles.row}>
                    <td className={styles.cell}/>
                    <td className={styles.cell}>
                        <div className={styles.card} id="demo">
                            <div className={classNames(styles.cardSide, styles.cardBack)}/>
                            <div className={classNames(styles.cardSide, styles.cardFace)}
                                 style={{backgroundImage: `url(${Background})`}}/>
                        </div>
                    </td>
                    <td className={styles.cell}/>
                    <td className={styles.cell}/>
                    <td className={styles.cell}/>
                </tr>
                <tr className={styles.row}>
                    <td className={styles.cell}/>
                    <td className={styles.cell}/>
                    <td className={styles.cell}>
                        <div className={styles.card}>
                            <div className={classNames(styles.cardSide, styles.cardBack)}/>
                            <div className={classNames(styles.cardSide, styles.cardFace)}
                                 style={{backgroundImage: `url(${Background})`}}/>
                        </div>
                    </td>
                    <td className={styles.cell}/>
                    <td className={styles.cell}/>
                </tr>
                <tr className={styles.row}>
                    <td className={styles.cell}/>
                    <td className={styles.cell}>
                        <div className={classNames(styles.card, styles.cardFlipped)}>
                            <div className={classNames(styles.cardSide, styles.cardBack)}/>
                            <div className={classNames(styles.cardSide, styles.cardFace)}
                                 style={{backgroundImage: `url(${Background})`}}/>
                        </div>
                    </td>
                    <td className={styles.cell}>
                        <div className={styles.card}>
                            <div className={classNames(styles.cardSide, styles.cardBack)}/>
                            <div className={classNames(styles.cardSide, styles.cardFace)}
                                 style={{backgroundImage: `url(${Background})`}}/>
                        </div>
                    </td>
                    <td className={styles.cell}/>
                    <td className={styles.cell}/>
                </tr>
            </table>
        );
    }
}
