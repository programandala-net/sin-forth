\ lib/type.fs

\ This file is part of Sin Forth.

\ This file adds `type` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260105.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-25: Complete with `after` and `count` after eForth.
\
\ 2020-12-26: Fix: require `drop`.
