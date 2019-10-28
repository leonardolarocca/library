import { FETCH_BOOKS, LOAD_BOOKS, DELETE_BOOK, INSERT_BOOK } from './actionTypes'

export const fetchBooks = () => {
  return { type: FETCH_BOOKS }
}

export const loadBooks = (data) => {
  return { type: LOAD_BOOKS, data }
}

export const deleteBook = (id) => {
  return { type: DELETE_BOOK, data: { id } }
}

export const insertBook = (data) => {
  return { type: INSERT_BOOK, data}
}
