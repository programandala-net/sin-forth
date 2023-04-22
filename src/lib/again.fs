\ lib/again.fs

\ This file is part of Sin Forth.

\ This file adds `again` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require branch.fs \ `branch`

get-order get-current

compiler-definitions

compiler{ synonym again branch }

  \ doc{
  \
  \ again
  \   Compilation: ( C: dest -- )
  \   Run-time:    ( -- )

  \
  \ Compilation: Compile an unconditional `branch`
  \ to the backward reference _dest_, usually left by `begin`.
  \
  \ Run-time: Continue execution at the location specified by
  \ _dest_.
  \
  \ See also: `until`, `repeat`.
  \
  \ }doc

set-current set-order
