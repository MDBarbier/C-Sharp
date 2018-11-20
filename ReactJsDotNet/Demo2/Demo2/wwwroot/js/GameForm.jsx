/* Form that allows a new game to be added to the list
 
 The constructor binds event handlers and also sets the state

 the "handle...." functions are event handlers for when the values change or when submit is clicked

in the render function call we render the actual HTML form and assign the properties from the state to it, and also use the onChange event to link
them to the handlers we set up.

The handleSubmit function prevents the default submit action, then calls the callback handler that was passed in by GameWidget with the values of the state 
 properties (which are linked to the input fields). Finally it clears down the input fields.
 
 */

class GameForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { Name: '', Genre: '', Price: '' };
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleGenreChange = this.handleGenreChange.bind(this);
        this.handlePriceChange = this.handlePriceChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleNameChange(e) {        
        this.setState({ Name: e.target.value });
    }
    handleGenreChange(e) {        
        this.setState({ Genre: e.target.value });
    }
    handlePriceChange(e) {        
        this.setState({ Price: e.target.value });
    }
    handleSubmit(e) {
        e.preventDefault();        
        const name = this.state.Name.trim();
        const genre = this.state.Genre.trim();
        const price = this.state.Price.trim();
        
        if (!name || !genre || !price) {
            return;
        }
        this.props.onGameSubmit({ Name: name, Genre: genre, Price: price });
        this.setState({ Name: '', Genre: '', Price: '' });
    }
    render() {
        return (
            <form className="gameForm" onSubmit={this.handleSubmit}>
                <input type="text" placeholder="Name" value={this.state.Name} onChange={this.handleNameChange} />
                <input type="text" placeholder="Genre" value={this.state.Genre} onChange={this.handleGenreChange} />
                <input type="text" placeholder="Price" value={this.state.Price} onChange={this.handlePriceChange}/>
                <input type="submit" value="Post" />
            </form>
        );
    }
}
