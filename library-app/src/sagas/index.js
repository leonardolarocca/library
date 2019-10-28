import { all, takeEvery } from 'redux-saga/effects'
import { fetchBooks, deleteBook, insertBook } from './book'
import { FETCH_BOOKS, DELETE_BOOK, INSERT_BOOK } from '../actions/actionTypes'

export default function* rootSaga () {
  yield all([
    takeEvery(FETCH_BOOKS, fetchBooks),
    takeEvery(DELETE_BOOK, deleteBook),
    takeEvery(INSERT_BOOK, insertBook)
  ])
}