import { useSelector, useDispatch } from 'react-redux'
import {
    increment,
    decrement,
    reset,
    incrementByAmount,
    decrementByAmount,
} from '../store/slices/counterSlice'
import {useState } from 'react'


const Counter = () => {

    const count = useSelector((state) => state.counter.count);
    const dispatch = useDispatch();

    const [incrementAmount, setIncrementAmount] = useState(0);
    const addValueNumber = Number(incrementAmount) || 0;


    const totalReset = () =>
    {
        dispatch(reset());
        setIncrementAmount(0);
    }

    const changeHandler = (event) => { /*console.log(event.target.value);*/ setIncrementAmount(event.target.value) }

    return (
        <div>
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <p aria-live="polite">Current count: <strong>{count}</strong></p>

            <button className="btn btn-primary" onClick={ () => dispatch(increment()) }>Increment</button>
            <button className="btn btn-secondary" onClick={() =>  totalReset() }>Reset</button>
            <button className="btn btn-primary" onClick={() => dispatch(decrement())}>Decrement</button>
            <hr />
            <input
                type="text"
                value={incrementAmount}
                onChange={changeHandler}
            />
            <br />
            <button className="btn btn-secondary" onClick={() => dispatch(incrementByAmount(  addValueNumber  ))}>Add Amount</button>
            <button className="btn btn-secondary" onClick={() => dispatch(decrementByAmount(  addValueNumber  ))}>Remove Amount</button>
        </div>
    );

}

export default Counter