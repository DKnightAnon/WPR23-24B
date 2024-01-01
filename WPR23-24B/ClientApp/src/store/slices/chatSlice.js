import { createSlice } from '@reduxjs/toolkit'


//this is the reducer?

export const chatSlice = createSlice({

    name: 'chatContent',
    initialState: {
        //content goes here
        content: []
    },

    reducers: {
        addNewMessage: (state,action) => {state.content = state.content.push(action.payload) },
        clearChat: (state) => {state.content = state.content.clear() },
        addConversationContent: (state, action) =>
        {
            state.content = action.payload
        }
    }




})

export const { addNewMessage, clearChat, addConversationContent } = chatSlice.actions

export default chatSlice.reducer