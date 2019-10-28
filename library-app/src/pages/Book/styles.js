import styled from 'styled-components'
import Button from 'react-bootstrap/Button'

export const Container = styled.section`
    padding: 100px
`;
export const StyledButton = styled(Button)`
    border-radius: 50%
`;

export const CommandColumn = styled.td`
    display: flex;
    justify-content: space-evenly
`;