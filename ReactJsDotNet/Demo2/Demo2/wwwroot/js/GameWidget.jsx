
/* 
 The GameWidget is the "top level" parent component which houses a GameList component and a GameForm component.

 The GameList has a list of GameItems, and the GameForm is for adding a new game to the list.

 The GameWidget sets up a recurring call to the server (in the componentDidMount function) to get an up to date lit of data. The data is assigned to the state which 
 is passed into the GameList for it to enumerate.

 It also handles submitting new content to the server, via a callback which it passes into GameForm for it to use.
 */
class GameWidget extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    componentDidMount() {
        
        window.setInterval(
            () => this.loadGamesFromServer(),
            this.props.pollInterval,
        );
    }
    loadGamesFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);            
            this.setState({ data: data });
        };
        xhr.send();        
    }  
    handleSubmit(game) {
        
        const data = new FormData();
        data.append('name', game.Name);
        data.append('genre', game.Genre);
        data.append('price', game.Price);
        
        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = () => this.loadGamesFromServer();
        xhr.send(data);
    }
    render() {
        return (
            <div className="gameWidget">This is the Game widget
                <GameList data={this.state.data} />
                <GameForm onGameSubmit={this.handleSubmit} />
            </div>                      
        );
    }
}

ReactDOM.render(<GameWidget url="/games" submitUrl="/games/new" pollInterval="10000" />, document.getElementById('content'));