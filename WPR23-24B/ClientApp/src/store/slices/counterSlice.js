import { createSlice } from '@reduxjs/toolkit'

const initialState = {
    count: 0
}

export const counterSlice = createSlice({
    name: 'counter',
    initialState,
    reducers: {

        //dispatch methods, these are called somewhere else in the code by using dispatch(method()) after properly importing the dispatch method.
        increment: (state) => { state.count += 1 },
        decrement: (state) => { state.count -= 1 },
        reset: (state) => { state.count = 0 },

        incrementByAmount: (state, action) => { state.count += action.payload },
        decrementByAmount: (state, action) => { state.count -= action.payload },
   
    }

})

export const { increment, decrement, reset, incrementByAmount, decrementByAmount } = counterSlice.actions;

export default counterSlice.reducer;