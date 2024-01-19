import { configureStore } from '@reduxjs/toolkit'
import chatReducer from './slices/chatSlice'
import counterReducer from './slices/counterSlice'
import chatroomReducer from './slices/chatroomSlice'
import userReducer from './slices/userSlice'


export const chatStore =  configureStore({
    reducer: {
        chatcontent: chatReducer,
        counter: counterReducer,
        chatroom: chatroomReducer,
        userLoginStatus: userReducer
    },
})