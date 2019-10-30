import React from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import BookForm from './pages/Book/bookForm'
import Book from './pages/Book';
import { Provider } from 'react-redux'
import store from './store'

export default class App extends React.Component {
  render() {
    return (
      <Provider store={store}>
      <Router>
      <Switch>
        <Route path="/">
          <Book />
        </Route>
        <Route path="/bookForm">
          <BookForm />
        </Route>
              
      </Switch>
    </Router>
      </Provider>
    )
  }
}
