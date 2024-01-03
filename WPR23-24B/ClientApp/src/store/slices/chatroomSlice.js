
import { createSlice, current } from '@reduxjs/toolkit'

const initialState = {
    //content goes here
    currentroom: []
}

export const chatroomSlice = createSlice({

    name: "chatroom",
    initialState,
    reducers:
    {

        setCurrentRoom: (state, action) =>
        {
            console.log("setCurrentRoom was triggered!");
            console.log(action);

            state.currentroom = action.payload;
        }


    }



}
)

export const { setCurrentRoom } = chatroomSlice.actions

export default  chatroomSlice.reducer