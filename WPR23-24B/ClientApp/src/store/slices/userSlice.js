import { createSlice, current } from '@reduxjs/toolkit'

const initialState = {
    //content goes here
    userLoginStatus: false
}

export const userSlice = createSlice({
    name: "userLoginStatus",
    initialState,
    reducers:
    {
        setUserLoginStatus: (state, action) => {

            console.group("UserStatus")
            console.log("User login status was toggled!")
            console.log(`Current status : ${action.payload}`)
            console.groupEnd()



            state.userLoginStatus = action.payload;
        }


    }




});


export const { setUserLoginStatus } = userSlice.actions;

export default userSlice.reducer;