import React, { Component } from 'react';

function Chat () {
    constructor(props) {
        super(props);

        this.state = {
            nick: '',
            message: '',
            messages: [],
            hubConnection: null,
        };
    }

    render() {
        return <div>Here goes chat</div>;
    }
}

export default Chat;