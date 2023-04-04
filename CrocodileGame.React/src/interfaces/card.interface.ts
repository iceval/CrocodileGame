import { TopicProps } from "./topic.interface"

export interface CardProps {
    id: number
    word: string
    topics?: TopicProps[]
}