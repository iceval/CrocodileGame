import { Link } from 'react-router-dom'

import './styles.scss'

export const Menu = () => {
return (
    <div className="menu">
      <div className="menu__title">CrocodileGame</div>
      <div className="menu__nav">
        <Link className="menu__link" to="/game">Play</Link>
        <Link className="menu__link" to="/editor">Edit Cards</Link>
      </div>
    </div>
  )
}