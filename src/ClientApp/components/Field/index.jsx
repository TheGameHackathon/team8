import React from 'react';
import styles from './styles.css'
import Cell from '../Cell'

const SIZE = 4;

export default class Field extends React.Component {
    constructor(props) {
        super(props);
        this.gameId = props.gameId;
    }
    
    render() {
        const rows = [];
        for (let i = 0; i < SIZE; i++)
            rows.push(this.renderRow(i));
        return (<div className={styles.field}>
            <table>
                <tbody>
                {rows}
                </tbody>
            </table>
        </div>);
    }

    renderRow(id) {
        const row = [];
        for (let i = 0; i < SIZE; i++)
            row.push(<Cell gameId={this.gameId} className="cell" key={i} id={id * 4 + i}/>);
        return (<tr key={id} className="row">
            {row}
        </tr>);
    }
}
