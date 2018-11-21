/* Data to fill the properties is passed in from the GameList component and is accessed via this.props */

class GameItem extends React.Component {
    render() {
        return (
            <div className="game">
                <h3 className="gameTitle">{this.props.name}</h3>                
                <p>Price: £{this.props.price}</p>
                <p>Genre: {this.props.genre}</p>
            </div>
        );
    }
}