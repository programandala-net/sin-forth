\ lib/repeat.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require again.fs \ `again`
require then.fs  \ `then`

get-order get-current

compiler-definitions

: repeat \ Compilation: ( orig dest -- )
         \ Run-time:    ( -- )
  compiler{ again then } ;

  \ doc{
  \
  \ repeat
  \   Compilation: ( C: orig dest -- )
  \   Run-time:    ( -- )

  \
  \ Compilation: Compile an unconditional `branch` to the backward
  \ reference _dest_, usually left by `begin`.  Resolve the
  \ forward reference _orig_, usually left by `while`.
  \
  \ Run-time: Continue execution at the location specified by
  \ _dest_.
  \
  \ See also: `again`, `then`, `until`.
  \
  \ }doc

set-current set-order
