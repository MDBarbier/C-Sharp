class GameWidget extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
    }
    componentDidMount() {
        
        window.setInterval(
            () => this.loadGamesFromServer(),
            this.props.pollInterval,
        );

        console.log("mounted the game widget and set the poll interval to " + this.props.pollInterval);
    }
    loadGamesFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            console.log("reply received: " + data);
            this.setState({ data: data });
        };
        xhr.send();
        console.log("loadGamesFromServerFired!");
    }    
    render() {
        return (
            <div className="gameWidget">This is the Game widget
                <GameList data={this.state.data} />
            </div>            
        );
    }
}

ReactDOM.render(<GameWidget url="/games" pollInterval="10000" />, document.getElementById('content'));