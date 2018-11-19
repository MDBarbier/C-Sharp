const data = [
    { Id: 1, Author: 'Matt Barbier', Text: 'Title1' },
    { Id: 2, Author: 'Matt Barbier', Text: 'Title2' },
    { Id: 3, Author: 'Matt Barbier', Text: 'Title3' },

];

//class CommentBox extends React.Component {
//    render() {
//        return (
//            <div className="commentBox">
//                <h1>Comments</h1>
//                <CommentList data={this.props.data} />
//                <CommentForm />
//            </div>)
//    }
//}

class CommentBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
    }
    componentDidMount() {
        this.loadCommentsFromServer();
        window.setInterval(
            () => this.loadCommentsFromServer(),
            this.props.pollInterval,
        );
    }
    loadCommentsFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }    
    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentList data={this.state.data} />
                <CommentForm />
            </div>
        );
    }
}



class CommentList extends React.Component {
    render() {
        const commentNodes = this.props.data.map(comment => (
            <Comment author={comment.Author} key={comment.Id}>
                {comment.Text}
            </Comment>
        ));

        return (

            <div className="commentList">{commentNodes}</div>
            
        );
    }
}

class CommentForm extends React.Component {
    render() {
        return (
            
            <div className="commentForm">Hello world! I am a Comment Form!</div>);
    }
}

class Comment extends React.Component {
    render() {
        return (
            <div className="comment">
                <h2 className="commentAuthor">{this.props.author}</h2>
                {this.props.children.toString()}
            </div>
            )
    }
}

//ReactDOM.render(<CommentBox data={data} />, document.getElementById('content'));
ReactDOM.render(
    <CommentBox url="/comments" pollInterval={10000} />,
    document.getElementById('content'),
);