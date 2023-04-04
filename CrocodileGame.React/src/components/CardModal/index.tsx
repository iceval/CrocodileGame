import { FC } from 'react'
import { CardProps } from "../../interfaces/card.interface"
import CardForm from '../CardForm'

import './styles.scss'

export interface ModalProps {
    isShowCardModal: boolean
    showCardModal: () => void
    card?: CardProps
}

const CardModal : FC<ModalProps> = ({ isShowCardModal, showCardModal, card }) => {
    return (
        <>
            {isShowCardModal && (
            <div className={`cardModal ${isShowCardModal ? 'active' : ''}`}>
                <CardForm showCardModal={showCardModal} card={card} />
            </div>
            )}
        </>
    )
}

export default CardModal