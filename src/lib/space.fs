\ lib/space.fs

\ This file is part of Sin Forth.

\ This file adds `space` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
