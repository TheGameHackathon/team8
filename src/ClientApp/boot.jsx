import React from 'react';
import ReactDom from 'react-dom';
import 'whatwg-fetch';
import './styles.css'
import {AppContainer} from 'react-hot-loader';
import App from './components/App';


function renderApp() {
    // This code starts up the React app when it runs in a browser. It sets up the routing
    // configuration and injects the app into a DOM element.
    fetch("http://localhost:5000/api/game/StartGame", {
        method: 'post',
    }).then(response => response.json())
        .then((id) =>
            ReactDom.render(
                <AppContainer>
                    <App gameId={id}/>
                </AppContainer>,
                document.getElementById('react-app')
            ));
}

renderApp();

// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept(App, () => {
        renderApp();
    });
}

