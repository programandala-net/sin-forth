\ lib/type.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require after.fs   \ `after`
require count.fs   \ `count`
require drop.fs    \ `drop`
require emit.fs    \ `emit`
require for.fs     \ `for`
require r-fetch.fs \ `r@`
require step.fs    \ `step`
require then.fs    \ `then`

get-order get-current

target-definitions

: type ( ca len -- )
  for after count emit then step drop ;

  \ doc{
  \
  \ type ( ca len -- )
  \
  \ If _len_ is greater than zero, display the character string
  \ _ca len_.
  \
  \ ----
  \ : type ( ca len -- )
  \   bounds ?do i c@ emit loop ;
  \ ----

  \ See also: `type-udg`.
  \
  \ }doc

set-current set-order
