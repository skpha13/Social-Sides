export function getTimeElapsed(postDate: string) {
  const currentDate = new Date();
  const timeDifference: number = currentDate.getTime() - new Date(postDate).getTime();

  const seconds: number = Math.floor(timeDifference / 1000);
  const minutes: number = Math.floor(seconds / 60);
  const hours: number = Math.floor(minutes / 60);
  const days: number = Math.floor(hours / 24);
  const weeks: number = Math.floor(days / 7);

  if (weeks >= 1) {
    return `${weeks}w`;
  } else if (days >= 1) {
    return `${days}d`;
  } else if (hours >= 1) {
    return `${hours}h`;
  } else if (minutes >= 1) {
    return `${minutes}m`;
  } else {
    return 'Just now';
  }
}