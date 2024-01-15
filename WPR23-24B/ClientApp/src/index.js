// import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import App from "./App.jsx";
import * as serviceWorkerRegistration from "./serviceWorkerRegistration";
import reportWebVitals from "./reportWebVitals";
import { AppProvider } from "./context";

import { Provider } from 'react-redux'
import { createStore } from 'redux'
import { chatStore } from './store/ReduxStore'








const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");
const root = createRoot(rootElement);




root.render(
    <React.StrictMode>
        <Provider store={chatStore}>
            <BrowserRouter basename={baseUrl}>
                <AppProvider>
                    <App />
                </AppProvider>
            </BrowserRouter>
        </Provider>
    </React.StrictMode>
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
serviceWorkerRegistration.unregister();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
