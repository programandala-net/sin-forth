\ lib/space.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1824+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
