import { createSlice, current } from '@reduxjs/toolkit'

const initialState = {
    //content goes here
    content: []
}

const printStateContent = () => {

            console.log('contentarray length :' + this.state.content)

            

            console.log('state contentArray contents:')

            //console.log(current(this.));
}

export const chatSlice = createSlice({

    name: 'chatContent',
    initialState,

    reducers: {
        addNewMessage: (state, action) =>
        {
            //console.log('chatSlice : addNewMessage triggered!')
            //console.log('payload content: ' + action.payload)
            const currentState = [...state.content]
            currentState.push(action.payload)
            state.content = currentState
            
            
            console.log('current state' + JSON.parse(JSON.stringify(state)))


        },
        clearChat: (state) => {state.content = [] },
        addConversationContent: (state, action) =>
        {
            console.log('addConversationContent was triggered!')
            console.log(action)

            state.content = action.payload


            //const currentState = [...state.content]
            //currentState.push(action.payload)
            //state.content = currentState
        },
        printTest: (state) => { console.log("printed from chatSlice") }
    }




})

export const { addNewMessage, clearChat, addConversationContent, printTest } = chatSlice.actions

/*export const chatContent = state => state.chatContent.content*/


export default chatSlice.reducer