import { configureStore } from '@reduxjs/toolkit'
import chatReducer from './slices/chatSlice'
import counterReducer from './slices/counterSlice'

export const chatStore =  configureStore({
    reducer: {
        chatcontent: chatReducer,
        counter: counterReducer,
    },
})