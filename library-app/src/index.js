import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux'
import 'bootstrap/dist/css/bootstrap.min.css';
import Book from './pages/Book';
import store from './store'
import App from './App';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'
import BooksForm from './pages/Book/bookForm';


ReactDOM.render(
  <Provider store={store}>
    <Router>
      <Switch>
        <Route path="/" component={Book} exact={true} />
        <Route path="/bookForm" component={BooksForm} />
      </Switch>
    </Router>,
  </Provider>,

  document.getElementById('root')
);

