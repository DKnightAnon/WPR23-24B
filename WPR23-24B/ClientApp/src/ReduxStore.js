import { configureStore } from '@reduxjs/toolkit'
import chatReducer from './components/Chat/chatSlice'

export default configureStore({
    reducer: {
        chatcontent: chatReducer
    },
})