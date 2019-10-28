import axios from 'axios'

const list = () => {
  return axios.get('http://localhost:5000/api/v1/library/book')
}

const destroy = (id) => {
  return axios.delete(`http://localhost:5000/api/v1/library/book/${id}`)
}

const create = (data) => {
  return axios.post('http://localhost:5000/api/v1/library/book', data)
}

export default { list, destroy, create }