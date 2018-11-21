class Item extends React.Component {
    render() {
        return (
            <div className="person">
                <h3 className="personName">{this.props.name}</h3>
                <p>Age: {this.props.age}</p>                
            </div>
        );
    }
}