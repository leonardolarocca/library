import { call, put } from 'redux-saga/effects'
import bookService from '../services/books'
import { loadBooks } from '../actions/book'

export function* fetchBooks () {
  const books = yield call(bookService.list)
  yield put(loadBooks(books.data))
}

export function* deleteBook (action) {
  const { data } = action

  yield call(bookService.destroy, data.id)
  yield call(fetchBooks)
}

export function* insertBook (action) {
  try {
    const { data } = action
  
    yield call(bookService.create, data)  
  } catch (err) {
    console.log(err)
  }
}