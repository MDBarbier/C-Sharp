/* The GameList has data passed in which is accessed via this.props.data 
  It then "maps" the items in the data list and outputs a GameItem component for each of them. It passes in the various attributes to the GameItem,
  and note especially the "key" property - this is a special property which React uses to keep track of things, it needs to be a unique value
 */

class GameList extends React.Component {
    render() {
        const gameData = this.props.data;
        
        const gameNodes = gameData.map(game =>             
            <GameItem name={game.name} price={game.price} genre={game.genre} key={game.id}/>
            );
        return (
            <div className="gameList">{gameNodes}</div>
        );
    }
}