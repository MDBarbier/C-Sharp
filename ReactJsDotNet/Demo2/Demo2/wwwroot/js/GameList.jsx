class GameList extends React.Component {
    render() {
        const gameData = this.props.data;
        console.log("Inside GameList, contents: " + gameData);
        const gameNodes = gameData.map(game => 
            <p>{game.name}</p>
            );
        return (
            <div className="gameList">{gameNodes}</div>
        );
    }
}