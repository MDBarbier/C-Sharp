class HelloWorld extends React.Component {
    constructor(props) {
        super(props);
        this.state = { name: this.props.name, data: this.props.data };
    }
    render() {
        const datalist = this.state.data.map(item => 
            <Item key={item.id} name={item.name} age={item.age} />
        );

        return (
            <div>
                Hello {this.state.name}!
                {datalist}                          
            </div>

        );
    }
}