\ lib/space.fs

\ This file is part of Sin Forth.

\ This file adds `space` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260221.
\ See change log at the end of the file.

\ ==============================================================

require b-l.fs  \ `bl`
require emit.fs \ `emit`

get-order get-current

target-definitions

: space ( -- )
  bl emit ;

  \ doc{
  \
  \ space ( -- )
  \
  \ Display one space.
  \
  \ See also: `bl`, `spaces`, `emit`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
