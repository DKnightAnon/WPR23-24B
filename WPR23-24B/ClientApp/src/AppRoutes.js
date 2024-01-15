import Chat from "./components/Chat/Chat";
import  Counter  from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import TestEnvironment from './components/TestEnvironment/TestEnvironment';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
        path: '/chat',
        element: <Chat/>
    },
    {
        path: '/test',
        element: <TestEnvironment />
    }
];

export default AppRoutes;
