import { LOAD_BOOKS } from '../actions/actionTypes'
const INITIAL_STATE = {}

export const reducer = (state = INITIAL_STATE, action) => {
  switch(action.type) {
    case LOAD_BOOKS: {
      return action.data
    }
    default:
      return state
  }
}